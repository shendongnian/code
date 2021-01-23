    // Creating Activities
    Guid oldID = Trace.CorrelationManager.ActivityId;
    Guid traceID = Guid.NewGuid();
    ts.TraceTransfer(0, "transfer", traceID);
    Trace.CorrelationManager.ActivityId = traceID; // Trace is static
    ts.TraceEvent(TraceEventType.Start, 0, "Add request");
    
    // Emitting Traces within a User Activity
    double value1 = 100.00D;
    double value2 = 15.99D;
    ts.TraceInformation("Client sends message to Add " + value1 + ", " + value2);
    double result = client.Add(value1, value2);
    ts.TraceInformation("Client receives Add response '" + result + "'");
    
    // Stopping the Activities
    ts.TraceTransfer(0, "transfer", oldID);
    ts.TraceEvent(TraceEventType.Stop, 0, "Add request");
    Trace.CorrelationManager.ActivityId = oldID;
