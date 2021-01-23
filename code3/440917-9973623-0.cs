    public FaceAPI faces_detect(List<string> urls, string filename, List<string> ownerIds, List<string> attributes, string callBackUrl)
    {
        List<string> list = this.prep_lists(urls, ownerIds, attributes);
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("urls", list[0]);
        dict.Add("owner_ids", list[1]);
        dict.Add("attributes", list[2]);
        dict.Add("_file", "@" + filename);
        dict.Add("callback_url", callBackUrl);
        return this.call_method("faces/detect", dict);
    }
