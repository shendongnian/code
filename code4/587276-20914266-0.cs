    class Foo
	{
		public Bar Bar { get; set; }
	}
	class Bar
	{
		public string Baz { get; set; }
	}
	class FooWithField
	{
		public BarWithField BarField;
	}
	class BarWithField
	{
		public string BazField;
	}
	public static class LambdaExtensions
	{
		public static object GetRootObject<T>(this Expression<Func<T>> expression)
		{
			var propertyAccessExpression = expression.Body as MemberExpression;
			if (propertyAccessExpression == null)
				return null;
			//go up through property/field chain
			while (propertyAccessExpression.Expression is MemberExpression)
				propertyAccessExpression = (MemberExpression)propertyAccessExpression.Expression;
			//the last expression suppose to be a constant expression referring to captured variable ...
			var rootObjectConstantExpression = propertyAccessExpression.Expression as ConstantExpression;
			if (rootObjectConstantExpression == null)
				return null;
			//... which is stored in a field of generated class that holds all captured variables.
			var fieldInfo = propertyAccessExpression.Member as FieldInfo;
			if (fieldInfo != null)
				return fieldInfo.GetValue(rootObjectConstantExpression.Value);
			return null;
		}
	}
	[TestFixture]
	public class Program
	{
		[Test]
		public void Should_find_root_element_by_property_chain()
		{
			var foo = new Foo { Bar = new Bar { Baz = "text" } };
			Expression<Func<string>> expression = () => foo.Bar.Baz;
			Assert.That(expression.GetRootObject(), Is.SameAs(foo));
		}
		[Test]
		public void Should_find_root_element_by_field_chain()
		{
			var foo = new FooWithField { BarField = new BarWithField { BazField = "text" } };
			Expression<Func<string>> expression = () => foo.BarField.BazField;
			Assert.That(expression.GetRootObject(), Is.SameAs(foo));
		}
	}
