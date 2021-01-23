        [Test]
        public void CreateMatrix()
        {
            var matrixVariableName = new Matrix(new [,] {{1, 2, 3,}, {1, 2, 3}});
            Assert.AreEqual("matrixVariableName", GetVariableName(() => matrixVariableName));
        }
        static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;
            return body.Member.Name;
        }
