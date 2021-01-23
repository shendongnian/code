    	public DataTable GetJobs()
		{
			DataTable table = new DataTable();
			table.Columns.Add("GroupName");
			table.Columns.Add("JobName");
			table.Columns.Add("JobDescription");
			table.Columns.Add("TriggerName");
			table.Columns.Add("TriggerGroupName");
			table.Columns.Add("TriggerType");
			table.Columns.Add("TriggerState");
			table.Columns.Add("NextFireTime");
			table.Columns.Add("PreviousFireTime");
			var jobGroups = GetScheduler().GetJobGroupNames();
			foreach (string group in jobGroups)
			{
				var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
				var jobKeys = GetScheduler().GetJobKeys(groupMatcher);
				foreach (var jobKey in jobKeys)
				{
					var detail = GetScheduler().GetJobDetail(jobKey);
					var triggers = GetScheduler().GetTriggersOfJob(jobKey);
					foreach (ITrigger trigger in triggers)
					{
						DataRow row = table.NewRow();
						row["GroupName"] = group;
						row["JobName"] = jobKey.Name;
						row["JobDescription"] = detail.Description;
						row["TriggerName"] = trigger.Key.Name;
						row["TriggerGroupName"] = trigger.Key.Group;
						row["TriggerType"] = trigger.GetType().Name;
						row["TriggerState"] = GetScheduler().GetTriggerState(trigger.Key);
						DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
						if (nextFireTime.HasValue)
						{
							row["NextFireTime"] = TimeZone.CurrentTimeZone.ToLocalTime(nextFireTime.Value.DateTime);
						}
						DateTimeOffset? previousFireTime = trigger.GetPreviousFireTimeUtc();
						if (previousFireTime.HasValue)
						{
							row["PreviousFireTime"] = TimeZone.CurrentTimeZone.ToLocalTime(previousFireTime.Value.DateTime);
						}
						table.Rows.Add(row);
					}
				}
			}
			return table;
		}
