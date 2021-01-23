    var compileUnit = new FluentCodeCompileUnit()
        .Namespace("Sample1")
                    .Class("Program")
                        .Method(MemberAttributes.Public | MemberAttributes.Static, "Main").Parameter(typeof(string[]), "args")
                            .CallStatic(typeof(Console), "WriteLine", Expr.Primitive("Hello Fluent CodeDom"))
                        .EndMethod
                        .Method(MemberAttributes.Public | MemberAttributes.Static, "Linq2CodeDomSupport").Parameter(typeof(string[]), "args")
                            .Stmt(ExprLinq.Expr(() => Console.WriteLine("Hello Linq2CodeDOM")))
                            .Declare(typeof(int), "random", ExprLinq.Expr(() => new Random().Next(10)))
                            .If((int random) => random <= 5)
                                .Stmt(ExprLinq.Expr(() => Console.WriteLine("Smaller or equal to 5.")))
                            .Else
                                .Stmt(ExprLinq.Expr(() => Console.WriteLine("Bigger than 5.")))
                            .EndIf
                        .EndMethod
                   .EndClass
                .EndNamespace
            .EndFluent();
            var assembly = Helper.CodeDomHelper.CompileInMemory(compileUnit);
            assembly.GetType("Sample1.Program").GetMethod("Main").Invoke(null, new object[] { null });
