    public class MyModel
    {
        public string parentName {get; set;}
        public string[] childrenNames { get; set; }
        public string JoinedNames { get; set; }
    }
    
    loo[1] = new MyModel();
    ..
    ...
    loo[1].JoinedNames  = string.Join("," loo[1].childrenNames);
    
    @(Html.Telerik().Grid(Model)
    .Columns(columns =>
    {
        columns.Bound(o => o.parentName).Width(100).Title("Parent");
        columns.Bound(o => o.JoinedNames).Width(250).Title("Kids");
     }
    
