    public IDbCommand CreateInsertCommand(object entity)
    {
        var entityTuplizer = GetTuplizer(_sessionMetadata.SessionImplementor);
        var values = entityTuplizer.GetPropertyValuesToInsert(entity, new Dictionary<object, object>(), _sessionMetadata.SessionImplementor);
        var notNull = GetPropertiesToInsert(values);
        var sql = GenerateInsertString(true, notNull);
        var insertCommand = _sessionMetadata.Batcher.Generate(sql.CommandType, sql.Text, sql.ParameterTypes);
        Dehydrate(null, values, notNull, _propertyColumnInsertable, 0, insertCommand, _sessionMetadata.SessionImplementor);
        InfraUtil.FixupGuessedType(insertCommand);
        return insertCommand;
    }
