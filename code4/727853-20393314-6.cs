    var list = new List<B>
                { 
                    new B(new A(new C(1))),
                    new B(new A(new C(2))),
                    new B(new A(new C(3))),
                    new B(new A(null)),
                    new B(null)
                }.AsQueryable();
    var ordered = list.OrderByDescending(GetExpression<B, Object>("AProp.CProp.Id"));
