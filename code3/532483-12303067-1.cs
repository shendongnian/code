    // (exists ((x Int)) (and (< t1 x) (< x t2))))
    Context z3 = new Context();
    Expr t1 = z3.MkIntConst("t1");
    Expr t2 = z3.MkIntConst("t2");
    Expr x = z3.MkIntConst("x");
    
    Expr p = z3.MkAnd(z3.MkLt((ArithExpr)t1, (ArithExpr)x), z3.MkLt((ArithExpr)x, (ArithExpr)t2));
    Expr ex = z3.MkExists(new Expr[] { x }, p);
    
    Goal g = z3.MkGoal(true, true, false);
    g.Assert((BoolExpr)ex);
    Tactic tac = Instance.Z3.MkTactic("qe"); // quantifier elimination
    ApplyResult a = tac.Apply(g); // look at a.Subgoals
                                            
