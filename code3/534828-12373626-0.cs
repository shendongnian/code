    public ObjHoldingData
    {
         public Display { get; set; }
         public Value { get; set; }
    }
    public class Form
    {
         Form()
         {
               var dataList = new List<ObjHoldingData>();
               //TODO: Fill list with all the data you pulled
               Listbox1.Datasource = dataList;
               Listbox1.DisplayMember = "Display";
               Listbox1.ValueMember = "Value";
         }
         protected void ButtonClick()
         {
              Listbox2.Datasource = Listbox1.SelectedItems.Cast<ObjHoldingData>().ToList();
              Listbox2.DisplayMember = "Display";
              Listbox2.ValueMember = "Value";               
         }
    }
