    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Simple POCO to use as row data in GridView
    /// </summary>
    public class Job
    {
        public int JobId { get; set; }
        public string Description { get; set; }
        public int MinLvl { get; set; }
        //etc
    }
    
    /// <summary>
    /// This will simulate a DAL that fetches data
    /// </summary>
    public class JobDal
    {
        private static int totalCount = 50; // let's pretend that db has total of 50 job records
        public IEnumerable<Job> GetJobs()
        {
            return Enumerable.Range(0, totalCount).Select(i => 
                new Job() { JobId = i, Description = "Descr " + i, MinLvl = i % 10 }); //simulate getting all records
        }
        public IEnumerable<Job> GetJobs(int maximumRows, int startRowIndex)
        {
            int count = (startRowIndex + maximumRows) > totalCount ? totalCount - startRowIndex : maximumRows;
            return Enumerable.Range(startRowIndex, count).Select(i => 
                new Job() { JobId = i, Description = "Descr " + i, MinLvl = i % 10 }); //simulate getting one page of records
        }
        public int GetTotalJobsCount()
        {
            return totalCount; // simulate counting total amount of rows
        }
    }
    
    /// <summary>
    /// Interface for our page, so we can call methods in the page itself
    /// </summary>
    public interface IJobDsPage
    {
        IEnumerable<Job> GetJobs();
        IEnumerable<Job> GetJobs(int maximumRows, int startRowIndex);
        int GetTotalJobsCount();
    }
    
    /// <summary>
    /// This will be used by our ObjectDataSource
    /// </summary>
    public class JobObjectDs
    {
        public IEnumerable<Job> GetJobs()
        {
            var currentPageAsIJobDsPage = (IJobDsPage)HttpContext.Current.CurrentHandler;
            return currentPageAsIJobDsPage.GetJobs();
        }
        public IEnumerable<Job> GetJobs(int maximumRows, int startRowIndex)
        {
            var currentPageAsIJobDsPage = (IJobDsPage)HttpContext.Current.CurrentHandler;
            return currentPageAsIJobDsPage.GetJobs(maximumRows, startRowIndex);
        }
        public int GetTotalJobsCount()
        {
            var currentPageAsIJobDsPage = (IJobDsPage)HttpContext.Current.CurrentHandler;
            return currentPageAsIJobDsPage.GetTotalJobsCount();
        }
    }
