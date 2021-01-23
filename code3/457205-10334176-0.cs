    public interface IMyCommonParent
    {
        bool Adding { get; set; }
        bool Editing { get; set; }
        bool Viewing { get; set; }
    }
    
    public class AdminStartMenu : DerivedFromSomeOtherClass, IMyCommonParent
    {  // being associated with IMyCommonParent, this class MUST have a declaration
       // of the "Adding", "Editing", "Viewing" boolean elements
    }
    
    public class TeacherStartMenu : DerivedFromSomeOtherClass, IMyCommonParent
    { // same here }
