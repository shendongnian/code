            var scriptOptions = new ScriptingOptions
                                    {
                                        ClusteredIndexes = true,
                                        Default = true,
                                        FullTextIndexes=true,
                                        Indexes=true,
                                        NonClusteredIndexes = true,
                                        SchemaQualify = true,
                                        DriAllConstraints = true
                                    };
            var tableScripts = table.Script(scriptOptions);
            String indexName = null;
            // Adjust to new table name
            sb.Replace(tableName, tableNameNew);
            //
            sb.Replace(partitionName, partitionName + "_New")
