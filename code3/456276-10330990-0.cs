    sealed class EmailTemplate {
      public static readonly EmailTemplate Welcome = new EmailTemplate("File1.html");
      public static readonly EmailTemplate Confirm = new EmailTemplate("File2.html");
    
      private EmailTemplate(string location) {
        Location = location;
      }
      public string Location { get; private set; }
      public string Render(Model data) { ... }
    }
