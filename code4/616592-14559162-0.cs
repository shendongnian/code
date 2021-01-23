     ObservableCollection<EmpData> _EmpDetail =
        new ObservableCollection<EmpData>();
      
      public ObservableCollection<EmpData> EmpDetail
        { get { return _EmpDetail; } }            
        public class EmpData
        {
            public int Id{ get; set; }
            public string Sex{ get; set; }
            public int name{ get; set; }                    
        }      
    
          var emplyees = from emp in emplyeeDetails.Descendants("Employee").Take(10)
                       orderby emp.Element("EmpId").Value ascending
                       select new
                       {
                           Id = emp.Element("EmpId").Value,
                           Name = emp.Element("Name").Value,
                           Sex = emp.Element("Sex").Value
                       };
          foreach (var Emp in emplyees )
            {                             
                _EmpDetail.Add(new EmpData
                {
                    Id= Emp.Id,
                    Sex= Emp.Sex,
                    Name= Emp.Name
                });
            }
       DgrdEmployeeDetails.ItemsSource = _EmpDetail;
     private void BtnGetSelectedRow_Click(object sender, RoutedEventArgs e)
    {
        EmpData dr= DgrdEmployeeDetails.SelectedItem as EmpData;
    }
