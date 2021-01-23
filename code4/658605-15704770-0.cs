    Dictionary<string,string> tags = new Dictionary<string,string>();
    
    public string UpadeInput(String input)
    {
        tags.Add("DTI", "DT");
        tags.Add("NNS", "NN");
        tags.Add("LongAnnoyingTag", "ShortTag");
        MatchEvaluator evaluator = new MatchEvaluator(ModifyTag);
        return Regex.Replace(input,"/(?<firstMatch>[^\s]+)(?= )", evaluator);
    }
    
    public string ModifyTag(Match match)
    {
        return tags[match.Value];
    }
