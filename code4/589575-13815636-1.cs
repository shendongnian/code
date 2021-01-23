    Visitor visitor = VisitorManager.CurrentVisitor;
    string name = visitor.Name;
    int age = visitor.Age;
    private const visitorSessionKey = "visitorSessionkey";
    public static Visitor CurrentVisitor
    {
        { 
             get { return (Visitor)Session[visitorSessionKey] ?? new Visitor(); }
        }
    }
