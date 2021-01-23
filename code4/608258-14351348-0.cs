    class ValidationNode
    {
        bool IsValid { get; }
        object EntityToValidatate { get; set; }
        string ErrorMessage { get; set; }
        ValidationNode Parent { get; set; } 
        IList<ValidationNode> Children { get; set; }
    }
