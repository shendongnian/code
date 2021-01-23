using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
interface IGizmo
{
    bool Frobnicate();
}
class Gizmo : IGizmo
{
    public bool Frobnicate()
    {
        Console.WriteLine("Gizmo was frobnicated!");
        return true;
    }
}
public sealed class DelegateConversionVisitor : ExpressionVisitor
{
    IDictionary&lt;ParameterExpression, ParameterExpression&gt; parametersMap;
    public static Expression&lt;Func&lt;T2, TResult&gt;&gt; Convert&lt;T1, T2, TResult&gt;(Expression&lt;Func&lt;T1, TResult&gt;&gt; expr)
    {
        var parametersMap = expr.Parameters
            .Where(pe =&gt; pe.Type == typeof(T1))
            .ToDictionary(pe =&gt; pe, pe =&gt; Expression.Parameter(typeof(T2)));
        var visitor = new DelegateConversionVisitor(parametersMap);
        var newBody = visitor.Visit(expr.Body);
        var parameters = expr.Parameters.Select(visitor.MapParameter);
        return Expression.Lambda&lt;Func&lt;T2, TResult&gt;&gt;(newBody, parameters);
    }
    public DelegateConversionVisitor(IDictionary&lt;ParameterExpression, ParameterExpression&gt; parametersMap)
    {
        this.parametersMap = parametersMap;
    }
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return base.VisitParameter(this.MapParameter(node));
    }
    private ParameterExpression MapParameter(ParameterExpression source)
    {
        var target = source;
        this.parametersMap.TryGetValue(source, out target);
        return target;
    }
}
class Program
{
    static void Main()
    {
        Expression&lt;Func&lt;IGizmo, bool&gt;&gt; expr = g =&gt; g.Frobnicate();
        var e2 = DelegateConversionVisitor.Convert&lt;IGizmo, Gizmo, bool&gt;(expr);
        var gizmo = new Gizmo();
        e2.Compile()(gizmo);
    }
}
