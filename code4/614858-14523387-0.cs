    @(
      Html.X().GridPanel()
                     .Title("Students")
                     .Width(550)
                     .Height(200)
                     .ForceFit(true)
                     .Store(Html.X().Store().Model(Html.X().Model()
                         .Fields(fields =>
                         {
    fields.Add(Html.X().ModelField().Name("StudentID"));
    fields.Add(Html.X().ModelField().Name("LastName"));
    fields.Add(Html.X().ModelField().Name("FirstMidName"));
    fields.Add(Html.X().ModelField().Name("EnrollmentDate"));
                         }
                         )
                     ).DataSource(Model)
         ).ColumnModel(
                 Html.X().Column().Text("Student ID").DataIndex("StudentID"),
             Html.X().Column().Text("Last Name").DataIndex("LastName"),
             Html.X().Column().Text("First Name").DataIndex("FirstMidName"),
    Html.X().DateColumn().Text("Enrollment").DataIndex("EnrollmentDate")
         ).DirectEvents(de =>
             {
                 de.CellDblClick.Url = "Edit"; // also tried
    de.CellDblClick.Action = "Edit";
                 de.CellDblClick.ExtraParams.Add(1);           //static
    later I'll add the StudentID here
             }
            )
    )
