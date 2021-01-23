    var list1 = oc as ObservableCollection<int>;
    var list2 = oc as ObservableCollection<string>;
    var list3 = oc as ObservableCollection<MyClass>;
    if (list1 != null)
        list1.Add(1);
    else if (list2 != null)
        list2.Add("str");
    else if (list3 != null)
        list3.Add(new MyClass());
    else
        throw new Exception("Unexpected object type.");
