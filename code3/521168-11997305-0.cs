    <CollectionViewSource x:Key="branchesViewSource"
            Source="{Binding Path=Branches, Source={StaticResource contactDBDataSet}}" />
                               //  ^  ^ ---------------------------------------
    contactDBDataSetBranchesTableAdapter.Fill(contactDBDataSet.Branches);//   |
                               //                                 ^  ^--------|
                               //             path matches so view is populated
    <CollectionViewSource x:Key="ranksViewSource"
            Source="{Binding Path=RankPath, Source={StaticResource contactDBDataSet}}" />
            //                     ^  ^---------------------------------------|
    contactDBDataSetArmyRanksTableAdapter.Fill(contactDBDataSet.ArmyRanks);// |
            //                                                     ^  ^-------|
            //                           These don't match so from code posted
            //                           view for ranksViewSource is still null   
