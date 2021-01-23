    protected void Page_Load(object sender, EventArgs e)
    {
       var animals = new List<Animal>();
       animals.Add(new Animal() { Name = "Doggie", Type = AnimalType.Dog});
       animals.Add(new Animal() { Name = "Sheepie", Type = AnimalType.Sheep });
       lstAnimals.DataSource = animals;
       lstAnimals.DataBind();
    }
       
    protected void lstAnimals_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var ddlAnimalType = (DropDownList)e.Item.FindControl("lstAnimalType");
        var enumValues = Enum.GetValues(typeof (AnimalType)).Cast<AnimalType>().ToList();
        var bindableList = enumValues.Select(v => new { Id = (int) v, Description = v.ToString() });
        ddlAnimalType.DataSource = bindableList;
        ddlAnimalType.DataBind();
    }
