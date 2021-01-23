    List<Block> blocks = new List<Block>();
    
    blocks.Add(new Block(1, "BlockName1", "BlockName2", "BlockName3"));
    blocks.Add(new Block(2, "BlockName4", "BlockName5"));
    blocks.Add(new Block(3, "BlockName6"));
    
    rptDummy.DataSource = blocks;
    rptDummy.DataBind();
