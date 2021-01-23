    class ScheduleDataCopier : IDataCopier
        {
            private List<Site> _sites;
            private List<SitesAndApparatuses> _scheduleList;
            private IRepositorySession _source;
            private (IRepositorySession _destination;
    
            public ScheduleDataCopier(IRepositorySession source, (IRepositorySession destination)
            {
                _source=source;
                _destination=destination;
                _scheduleList = new List<SitesAndApparatuses>();
            }
    
            //check if new sites registration has arrived in tblSites on down from web db.
            public bool DetectChanges()
            {
    		
                    SiteAudit lastSite = new SitesAuditRepository().GetLatest();
                    var sitesRepo = new SitesRepository();
                    var sites = sitesRepo.Where(x => x.SID > lastSite.SALatestSID);
    
                    if (sites.Count() < 1)
                    {
                        return false;
                    }
                    _sites = sites.ToList();
                    _source.DoSomething();
                    _source.CommitAndReleaseResources();//clean up but leave object reusable
                return true;
            }
            //parse the data into a list of object SitesAndApparatuses
            public bool ParseData()
            {
                try
                {
                    foreach (Site s in _sites)
                    {
                        var schedule = (SitesAndApparatuses)XmlObjectBuilder.Deserialize(typeof(SitesAndApparatuses), s.XMLFile);
                        schedule.acCode = s.Registration.RAcCode;
                        _scheduleList.Add(schedule);
                    }
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException("HANDLE THIS SHIT!", ex);
                }
                return true;
            }
    
            public bool CopyData()
            {
                try
                {
    
                   
                            var licensingScheduleRepo = new LicensingScheduleRepository();
                           //some logic
                        _desitnation.Commit();
                    
                }
                catch (Exception ex)
                {
                }
                    return true;
            }
    }
