            try
            {
                using (SqlCeCommand command = conn.CreateCommand())
                {
                    command.CommandText = "Holdings";
                    command.CommandType = CommandType.TableDirect;
                    using (SqlCeResultSet rs = command.ExecuteResultSet(ResultSetOptions.Updatable | ResultSetOptions.Scrollable))
                    {
                        SqlCeUpdatableRecord record = rs.CreateRecord();
                        foreach (var r in _commitBatch)
                        {
                            int index=0;
                            record.SetValue(index++, r.TryGetValueOrDefault("IdentifierFromImportSource",string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("SecurityID", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("SecurityName", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("SecurityType", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("AllocationAmount", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("Position", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("AnnualFeePercent", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("MarginAmount", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("Price", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("MorningstarSecId", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("MorningstarSecType", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("UserID", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("MorningstarPrice", string.Empty));
                            record.SetValue(index++, string.Empty);
                            record.SetValue(index++, r.TryGetValueOrDefault("AnnualFeeFrequency", string.Empty));
                            record.SetValue(index++, r.TryGetValueOrDefault("TrackingMethod", "1"));
                            rs.Insert(record);
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                NotifyError(this, new ImportErrorEventArgs(e.Message + e.StackTrace, ErrorLevel.Application));
            }
