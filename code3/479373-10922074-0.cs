    class Message
    {
        CommonProperties Common { get; set; }
        // Property Name / Property Value.  Alternatively use a Tuple to also hold the type if needed.
        Dictionary<string, object> IndividualProperties { get; set; }
    }
