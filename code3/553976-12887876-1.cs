	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Linq.Expressions;
	namespace ConsoleApplication4
	{
		[DebuggerDisplay("{Condition} on {EvaluationTarget} is {EvaluationResult}")]
		public class ReportItem<T>
		{
			public string Condition { get; private set; }
			public IEnumerable<ReportItem<T>> NestedReports { get; private set; }
			public object EvaluationResult { get; private set; }
			public T EvaluationTarget { get; private set; }
			public ReportItem(Expression condition, IEnumerable<ReportItem<T>> nestedReports, T evaluationTarget, object evaluationResult)
			{
				Condition = condition.ToString();
				NestedReports = nestedReports;
				EvaluationTarget = evaluationTarget;
				EvaluationResult = evaluationResult;
			}
			public override string ToString()
			{
				return string.Format("{0} on {1} is {2}", Condition, EvaluationTarget, EvaluationResult);
			}
		}
		[DebuggerDisplay("Included: {IsIncludedInResult} \n{Summary}")]
		public class Report<T>
		{
			public ReportItem<T> Contents { get; private set; }
			public T EvaluationTarget { get; private set; }
			public Report(T source, Expression<Func<T, bool>> predicate)
			{
				EvaluationTarget = source;
				IsIncludedInResult = predicate.Compile()(source);
				Contents = Recurse(predicate.Parameters.Single(), predicate.Body, source);
			}
			private object Evaluate(Expression expression, ParameterExpression parameter, T source)
			{
				var expr = Expression.Lambda(expression, parameter);
				var @delegate = expr.Compile();
				var value = @delegate.DynamicInvoke(source);
				return value;
			}
			private ReportItem<T> Recurse(ParameterExpression parameter, Expression sourceExpression, T source)
			{
				var constantExpression = sourceExpression as ConstantExpression;
				if(constantExpression != null)
				{
					return new ReportItem<T>(sourceExpression, null, source, Evaluate(constantExpression, parameter, source));
				}
				var unaryExpression = sourceExpression as UnaryExpression;
				if(unaryExpression != null)
				{
					var content = Recurse(parameter, unaryExpression.Operand, source);
					var result = Evaluate(sourceExpression, parameter, source);
					return new ReportItem<T>(sourceExpression, new[]{content}, source, result);
				}
				var binaryExpression = sourceExpression as BinaryExpression;
				if(binaryExpression != null)
				{
					var left = Recurse(parameter, binaryExpression.Left, source);
					var right = Recurse(parameter, binaryExpression.Right, source);
					var item = new ReportItem<T>(sourceExpression, new[] {left, right}, source, Evaluate(sourceExpression, parameter, source));
					return item;
				}
				var methodCallExpression = sourceExpression as MethodCallExpression;
				if(methodCallExpression != null)
				{
					var args = methodCallExpression.Arguments.Select(x => Evaluate(x, parameter, source)).ToArray();
					var result = methodCallExpression.Method.Invoke(Expression.Lambda(methodCallExpression.Object, parameter).Compile().DynamicInvoke(source), args);
					return new ReportItem<T>(sourceExpression, null, source, result);
				}
				throw new Exception("Unhandled expression type " + sourceExpression.NodeType + " encountered");
			}
			public bool IsIncludedInResult { get; private set; }
			public string Summary
			{
				get { return Contents.ToString(); }
			}
			public override string ToString()
			{
				return Summary;
			}
		}
		public static class PredicateRunner
		{
			public static IEnumerable<Report<T>> Report<T>(this IEnumerable<T> set, Expression<Func<T, bool>> predicate)
			{
				return set.Select(x => new Report<T>(x, predicate));
			}
		}
		class MyItem
		{
			public string Name { get; set; }
			public int Value { get; set; }
			public override int GetHashCode()
			{
				return Value % 2;
			}
			public override string ToString()
			{
				return string.Format("Name: \"{0}\" Value: {1}", Name, Value);
			}
		}
		class Program
		{
			static void Main()
			{
				var items = new MyItem[3];
				items[0] = new MyItem
				{
					Name = "Hello",
					Value = 1
				};
				items[1] = new MyItem
				{
					Name = "Hello There",
					Value = 2
				};
				items[2] = new MyItem
				{
					Name = "There",
					Value = 3
				};
				var result = items.Report(x => !x.Name.Contains("Hello") && x.GetHashCode() == 1).ToList();
				Debugger.Break();
			}
		}
	}
