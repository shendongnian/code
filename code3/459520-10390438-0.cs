    public class Branch
    {
      public int ID {get;set;}
      public string BranchName {get;set;}
      public string Department {get;set;}
      public bool Available {get;set;}
    }
    
    public bool BranchExists(int id, string branch, string dept)
    {
       //assume "Branches" is your in-memory list
       return Branches.Any(b => b.id == id && b.BranchName == branch && b.Department == dept);
    }
