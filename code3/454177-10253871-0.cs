        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ "DistID" ] != "" )
            {
                var distId = Session[ "DistID" ];
                if (distId != null) {
                  DistInfo distInfo = GeneralFunctions.GetGeneralInformation( ( int )Session[ "DistID" ] );
                  launchDate.Text = distInfo.AnticipatedLaunchDate.ToShortDateString();
                } else {
                  // default display value
                }
            }
        }
