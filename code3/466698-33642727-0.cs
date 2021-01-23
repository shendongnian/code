    @if ((Model.CustomerOrderTrackings != null) && (Model.CustomerOrderTrackings.Count > 0)) {
        for (int i = 0; i < Model.CustomerOrderTrackings.Count; i++) {
            @Html.EditorFor(m => m.CustomerOrderTrackings[i])
        }
    } else {
        @{ CustomerOrderTracking stubModel = new CustomerOrderTracking(); }
        @Html.EditorFor(m => stubModel)
    }
