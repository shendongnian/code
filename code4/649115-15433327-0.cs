    using namespace System;
    
    /* <stmt> := var <ident> = <expr>
        | <ident> = <expr>
        | for <ident> = <expr> to <expr> do <stmt> end
        | read_int <ident>
        | print <expr>
        | <stmt> ; <stmt>
      */
    public ref class Stmt abstract
    {
    };
    /* <expr> := <string>
     *  | <int>
     *  | <arith_expr>
     *  | <ident>
     */
    public ref class Expr abstract
    {
    };
    // <bin_op> := + | - | * | /
    public enum class BinOp
    {
        Add,
        Sub,
        Mul,
        Div
    };
    
    // var <ident> = <expr>
    public ref class DeclareVar : Stmt
    {
    public:
        String^ Ident;
        Expr^ expr;
    };
    
    // print <expr>
    public ref class Print : Stmt
    {
    public:
        Expr^ Expr;
    };
    
    // <ident> = <expr>
    public ref class Assign : Stmt
    {
    public:
        String^ Ident;
        Expr^ Expr;
    };
    
    // for <ident> = <expr> to <expr> do <stmt> end
    public ref class ForLoop : Stmt
    {
    public:
        String^ Ident;
        Expr^ From;
        Expr^ To;
        Stmt^ Body;
    };
    
    // read_int <ident>
    public ref class ReadInt : Stmt
    {
    public:
        String^ Ident;
    };
    
    // <stmt> ; <stmt>
    public ref class Sequence : Stmt
    {
    public:
        Stmt^ First;
        Stmt^ Second;
    };
    
    
    // <string> := " <string_elem>* "
    public ref class StringLiteral : Expr
    {
    public:
        String^ Value;
    };
    
    // <int> := <digit>+
    public ref class IntLiteral : Expr
    {
    public:
        int Value;
    };
    
    // <ident> := <char> <ident_rest>*
    // <ident_rest> := <char> | <digit>
    public ref class Variable : Expr
    {
    public:
        String^ Ident;
    };
    
    // <bin_expr> := <expr> <bin_op> <expr>
    public ref class BinExpr : Expr
    {
    public:
        Expr^ Left;
        Expr^ Right;
        BinOp Op;
    };
    
