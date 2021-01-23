            var qryPartnerJobs = (from pj in at.jobs
                                 join jq in at.job_quotes on pj.JobID equals jq.JobID
                                 join u in at.users on jq.TradeUserID equals u.UserID
                                 where pj.IsApproved == true
                                 select new 
                                 {
                                     JobID = pj.JobID,
                                     FirstName = u.FirstName,
                                     ServiceName = pj.service.ServiceName,
                                     ServiceTypeName = pj.service_type.ServiceTypeName,
                                     IsApproved = pj.IsApproved,
                                     IsActive = pj.IsActive,
                                     IsQuoted = pj.IsQuoted,
                                     IsAssigned = pj.IsAssigned,
                                     ApprovalDate = pj.ApprovalDate,
                                     Description = pj.Description
                                 })
                                 // get a group for each distinct jobId
                                 .GroupBy(t => t.JobID)
                                 // select the first entry from each group
                                 .SelectMany(g => g.Take(1));
