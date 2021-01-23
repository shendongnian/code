        public override string GetDmlCommand()
        {
            //Recover Table Name
            StringBuilder updateCommand = new StringBuilder();
            updateCommand.Append("UPDATE ");
            updateCommand.Append(MetadataAccessor.GetTableNameByEdmType(
                                      typeof(T).Name));
            updateCommand.Append(" ");
            updateCommand.Append(setParser.ParseExpression());
            updateCommand.Append(whereParser.ParseExpression());
            return updateCommand.ToString();
        }
