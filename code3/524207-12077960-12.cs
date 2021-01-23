    public class PersonViewModel {
      private Person model;
      public PersonViewModel(Person model) {
          this.model = model;
      }
    
      public Guid Uid { get { return model.Uid; } }
          
      public string Name { get { return model.Name; } }
    
      public string Company { get { return model.Company; } }
      public bool IsChecked { get; set; }
    }
