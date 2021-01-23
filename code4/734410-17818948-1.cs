    class Stats {
        // Contains properties as you defined ...
    }
    var stats = new Stats(...);
    int leftColWidth = 16;
    int rightColWidth = 13;
    var sb = new StringBuilder();
    sb.AppendLine("=----------------------------------=");
    sb.Append("= ");
    sb.Append(("Strength: " + stats.Strength.ToString()).PadRight(leftColWidth));
    sb.Append(" | ");
    sb.Append(("Agility: " + stats.Agility.ToString()).PadRight(rightColWidth));
    // And so on.
