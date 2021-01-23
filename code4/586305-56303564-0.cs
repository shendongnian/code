    var scaffoldedMigration
        = _configuration.CodeGenerator.Generate(
            migrationId,
            migrationOperations,
            (sourceModel == _emptyModel.Value)
            || (sourceModel == _currentModel)
            || !sourceMigrationId.IsAutomaticMigration()
                ? null
                : Convert.ToBase64String(modelCompressor.Compress(sourceModel)),
            Convert.ToBase64String(modelCompressor.Compress(_currentModel)),
            @namespace,
            migrationName);
