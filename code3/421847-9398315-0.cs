      public class Person
      {
           public string FirstName { get; set; }
           public string FirstInitial
           {
               get { return FirstName != null ? FirstName.Substring(0,1) : ""; }
           }
 
           ...
       }
       @Html.DisplayFor( modelItem => modelItem.FirstInitial )
