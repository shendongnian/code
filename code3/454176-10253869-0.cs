    string distId = Session[ "DistID" ];    
    int distIdValue;
    if( !string.IsNullOrWhiteSpace( distId ) && integer.TryParse( distId, out distIdValue ) )
    {
        DistInfo distInfo = GeneralFunctions.GetGeneralInformation( distIdValue );
        launchDate.Text = distInfo.AnticipatedLaunchDate.ToShortDateString();
    }
