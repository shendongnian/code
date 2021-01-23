    struct RequestStatus {
      // implement as desired
      public StatusType Type { get; set; }
      public Status Status { get; set; }
    }
    Action RequestingStatusA (RequestStatus status) {
      ..
    }
