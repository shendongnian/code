    [TestMethod]
    public void test()
    {
        var evalTable = new DataTable();
        using (var evalExpressionColumn = new DataColumn("EvaluateExpression", typeof(double), "0"))
        {
            evalTable.Columns.Add(evalExpressionColumn);
        }
        evalTable.Rows.Add(0);
        evalTable.Columns[0].Expression = "(5 + 4 ) * 8";
        //Note: Evaluate expression.
        var res = Convert.ToDouble(evalTable.Rows[0]["EvaluateExpression"]);
        Assert.AreEqual(72, res);
    }
