    class ManagedItems {
       IList<Department> Departments // TreeView.ItemsSource
    }
    class Department {// HierDT
       IList<object> Children // HierDT.ItemsSource; (can either be Department or Client)
    }
    class Client {// HierDT
       IList<Feature> Features // HierDT.ItemsSource
    }
    class Feature { } // normal DataTemplate
