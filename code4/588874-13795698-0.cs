    // Prints the string representation of the recurrence rule:
    string rruleAsString = rrule.ToString();
    Console.WriteLine("Recurrence rule:\n\n{0}\n", rruleAsString);
    // The string representation can be stored in a database, etc.
    // ...
    // Then it can be reconstructed using TryParse method:
    RecurrenceRule parsedRule;
    RecurrenceRule.TryParse(rruleAsString, out parsedRule);
    Console.WriteLine("After parsing (should be the same):\n\n{0}", parsedRule);
