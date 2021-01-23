    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    
    public partial class GridViewTest : System.Web.UI.Page, IJobDsPage
    {
        bool gridNeedsBinding = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridNeedsBinding = true;
            }
        }
        protected void jobsGv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gv = (GridView)sender;
            newPageIndexForGv = e.NewPageIndex;
            gridNeedsBinding = true;
        }
        private int newPageIndexForGv = 0;
        protected void Page_PreRendercomplete(object sender, EventArgs e)
        {
            if (gridNeedsBinding)
            {
                // fetch data into this.jobs and this.totalJobsCount to simulate 
                // that data has just become available asynchronously
                JobDal dal = new JobDal();
                jobs = dal.GetJobs(jobsGv.PageSize, jobsGv.PageSize * newPageIndexForGv).ToList();
                totalJobsCount = dal.GetTotalJobsCount();
    
                //now that data is available, bind gridview
                jobsGv.DataBind();
                jobsGv.SetPageIndex(newPageIndexForGv);
            }
        }
    
        #region JobDsPage Members
    
        List<Job> jobs = new List<Job>();
        public IEnumerable<Job> GetJobs()
        {
            return jobs;
        }
        public IEnumerable<Job> GetJobs(int maximumRows, int startRowIndex)
        {
            return jobs;
        }
        int totalJobsCount;
        public int GetTotalJobsCount()
        {
            return totalJobsCount;
        }
    
        #endregion
    
        protected void button_Click(object sender, EventArgs e)
        {
        }
    }
