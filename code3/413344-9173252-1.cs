    public void Populate(Guid UserId)
		{
			DAL db = new DAL();
			using (SqlConnection con = db.GetConnection())
			{
				con.Open();
				string sqlQuery = "SELECT [ApplicationId],[UserId],[Password],[PasswordFormat],[PasswordSalt],[MobilePIN]," +
					"[Email],[LoweredEmail],[PasswordQuestion],[PasswordAnswer],[IsApproved],[IsLockedOut],[CreateDate],[LastLoginDate],[LastPasswordChangedDate],[LastLockOutDate]," +
					"[FailedPasswordAttemptCount],[FailedPasswordAttemptWindowStart],[FailedPasswordAnswerAttemptCount],[FailedPasswordAnswerAttemptWindowStart],[Comment]," +
					"[FirstName],[LastName],[Address] FROM aspnet_Membership WHERE [UserId]=@UserId";
				using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, con))
				{
					sqlCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = UserId });
					try
					{
						using (SqlDataReader rdr = sqlCommand.ExecuteReader())
						{
							if (rdr.HasRows)
							{
								while (rdr.Read())
								{
									this.ApplicationId = (Guid)rdr["ApplicationID"];
									this.UserId = (Guid)rdr["UserId"];
									this.Password = common.Coalesce(rdr["Password"], "");
									this.PasswordFormat = common.Coalesce(rdr["PasswordFormat"], 0);
									this.PasswordSalt = common.Coalesce(rdr["PasswordSalt"], "");
									this.MobilePIN = common.Coalesce(rdr["MobilePIN"], "");
									this.Email = common.Coalesce(rdr["Email"], "");
									this.LoweredEmail = common.Coalesce(rdr["LoweredEmail"], "");
									this.PasswordQuestion = common.Coalesce(rdr["PasswordQuestion"], "");
									this.PasswordAnswer = common.Coalesce(rdr["PasswordAnswer"], "");
									this.IsApproved = (bool)rdr["IsApproved"];
									this.IsLockedOut = (bool)rdr["IsLockedOut"];
									this.CreateDate = common.Coalesce(rdr["CreateDate"], DateTime.Now);
									this.LastLoginDate = common.Coalesce(rdr["LastLoginDate"], DateTime.Now);
									this.LastPasswordChangedDate = common.Coalesce(rdr["LastPasswordChangedDate"], DateTime.Now);
									this.LastLockOutDate = common.Coalesce(rdr["LastLockOutDate"], DateTime.Now);
									this.FailedPasswordAttemptCount = common.Coalesce(rdr["FailedPasswordAttemptCount"], 0);
									this.FailedPasswordAttemptWindowStart = common.Coalesce(rdr["FailedPasswordAttemptWindowStart"], DateTime.Now);
									this.FailedPasswordAnswerAttemptCount = common.Coalesce(rdr["FailedPasswordAnswerAttemptCount"], 0);
									this.FailedPasswordAnswerAttemptWindowStart = common.Coalesce(rdr["FailedPasswordAnswerAttemptWindowStart"], DateTime.Now);
									this.Comment = common.Coalesce(rdr["Comment"], "");
									this.FirstName = common.Coalesce(rdr["FirstName"], "");
									this.LastName = common.Coalesce(rdr["LastName"], "");
									this.Address = common.Coalesce(rdr["Address"], 0);
								}
							}
						}
					}
					catch
					{
						throw;
					}
				}
			}
		}
