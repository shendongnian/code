    class entity
        {
        protected int hp;
        protected string name;
    ...
    
    
    class dragon : entity
        {
    
        // new public string name;  - you're creating new variables hiding the base ones
        // new int hp;              - ditto. Don't need them
    ....
