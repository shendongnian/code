    using System.Collections.ObjectModel;
    ...
    class MyOC : ObservableCollection<SampleDataGroup> { };
    ...
    var oc = new MyOC();
    string id = "title1";
    oc.Add(new SampleDataGroup(id, id, id, "", id));
    id = "title2";
    oc.Add(new SampleDataGroup(id, id, id, "", id));
    this.DefaultViewModel["Groups"] = oc;
