    Helper.ExecuteNonQuery(command =>
    {
      command.CommandText = SchemaDifferenceFinder.Model.SQLStatements.MissingTables.DropTable;
      command.CommandType = System.Data.CommandType.Text;
    });
