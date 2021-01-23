    reader.ReadToFollowing("status");
    output.AppendLine(reader.ReadElementContentAsString());
    
    reader.ReadToFollowing("number");
    output.AppendLine(reader.ReadElementContentAsString());
