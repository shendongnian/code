    class CustomOracleSqlCodeGen : MigrationSqlGenerator
    {
        // the actual SQL generator
        private readonly MigrationSqlGenerator _innerSqlGenerator;
        public CustomOracleSqlCodeGen(MigrationSqlGenerator innerSqlGenerator)
        {
            _innerSqlGenerator = innerSqlGenerator;
        }
        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            var ms = _innerSqlGenerator.Generate(AddCommentSqlStatements(migrationOperations), providerManifestToken);
            
            return ms;
        }
        
        // generate additional SQL operations to produce comments
        IEnumerable<MigrationOperation> AddCommentSqlStatements(IEnumerable<MigrationOperation> migrationOperations)
        {
            foreach (var migrationOperation in migrationOperations)
            {
                // the original inputted operation
                yield return migrationOperation;
                // create additional operations to produce comments
                if (migrationOperation is CreateTableOperation cto)
                {
                    foreach (var ctoAnnotation in cto.Annotations.Where(x => x.Key == "Comment"))
                    {
                        if (ctoAnnotation.Value is string annotation)
                        {
                            var commentString = annotation.Replace(
                                CommentConvention.NewLinePlaceholder,
                                Environment.NewLine);
                            yield return new SqlOperation($"COMMENT ON TABLE {cto.Name} IS '{commentString}'");
                        }
                    }
                    foreach (var columnModel in cto.Columns)
                    {
                        foreach (var columnModelAnnotation in columnModel.Annotations.Where(x => x.Key == "Comment"))
                        {
                            if (columnModelAnnotation.Value is AnnotationValues annotation)
                            {
                                var commentString = (annotation.NewValue as string)?.Replace(
                                    CommentConvention.NewLinePlaceholder,
                                    Environment.NewLine);
                                yield return new SqlOperation(
                                    $"COMMENT ON COLUMN {cto.Name}.{columnModel.Name} IS '{commentString}'");
                            }
                        }
                    }
                }
            }
        }
    }
