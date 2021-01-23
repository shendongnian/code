    var query = (from b in db.FourBodyImages
                 where b.Status == true
                 orderby b.CreaedDate descending
                 select new { b.BodyImage, b.Description, b.HeaderName }
                 ).Take(4).ToArray();
    var bodies = new[] { imgBody1, imgBody2, imgBody3, imgBody4 };
    for (int i = 0; i < query.Length; i++)
    {
        // Or whichever property you're interested in...
        bodies[i].ImageUrl = "FourBodyImages/" + query[i].BodyImage;
    }
