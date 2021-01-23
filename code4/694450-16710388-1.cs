    Dictionary<string, LinkAct> postActivity = new[]
                        {                           
                            new {Key="ActivityId63", Value=new LinkAct {LikeActId= 61, CommentActId = 63, CommentLikeActId = 79 }},
                            new {Key="ActivityId67", Value=new LinkAct {LikeActId= 65, CommentActId = 67, CommentLikeActId = 78}},
                            new {Key="ActivityId75", Value=new LinkAct {LikeActId= 73, CommentActId = 75, CommentLikeActId = 80}},
                            new {Key="ActivityId83", Value=new LinkAct {LikeActId= 82, CommentActId = 83, CommentLikeActId = 84}}
                       }.ToDictionary(kv => kv.Key, kv => kv.Value);
    
        int a = postActivity["ActivityId63"].LikeActId;
