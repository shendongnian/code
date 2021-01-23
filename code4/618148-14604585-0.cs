    gridControl1.DataSource = new List<Person> { 
        new Person(){ Name = "John", Age = 25 },
        new Person(){ Name = "Mary", Age = 17 },
        new Person(){ Age = 17  },
        new Person(){ Name = "Ann" },
        new Person(){ Name = "Pit", Age = 5 },
    };
    StyleFormatCondition nameCondition = new StyleFormatCondition();
    nameCondition.Column = gridView1.Columns["Name"];
    nameCondition.Condition = FormatConditionEnum.Expression;
    nameCondition.Expression = "IsNullOrEmpty([Name])";
    nameCondition.Appearance.BackColor = Color.Red;
    nameCondition.Appearance.Options.UseBackColor = true;
    
    StyleFormatCondition ageCondition = new StyleFormatCondition();
    ageCondition.Column = gridView1.Columns["Age"];
    ageCondition.Condition = FormatConditionEnum.Expression;
    ageCondition.Expression = "[Age]<10";
    ageCondition.Appearance.BackColor = Color.Maroon;
    ageCondition.Appearance.Options.UseBackColor = true;
    
    gridView1.FormatConditions.AddRange(new StyleFormatCondition[] { 
        nameCondition, ageCondition
    });
