     public static class Qs
        {
            public sealed class Act
            {
                //private Act();
                public const string edit = "edit", add = "add", remove = "remove", replace = "replace";
            }
           public sealed class State
            {
               public const string addnewTableRow = "addnewTableRow", cancelInsert = "cancelInsert", loadpagefromlink="loadpagefromlink";
            }
           public sealed class Params
            {
                 public const string state = "state";
                 public const string custID = "custID";
                 public const string recordID = "recordID";
            }
