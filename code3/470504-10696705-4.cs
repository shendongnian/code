    public event SubmitClickedHandler SubmitClicked;
    // Add a protected method called OnSubmitClicked().
    // You may use this in child classes instead of adding
    // event handlers.
    protected virtual void OnSubmitClicked()
    {
      // If an event has no subscribers registerd, it will
      // evaluate to null. The test checks that the value is not
      // null, ensuring that there are subsribers before
      // calling the event itself.
         if (SubmitClicked != null)
         {
           SubmitClicked();  // Notify Subscribers
         }
         }
      // Handler for Submit Button. Do some validation before
      // calling the event.
    private void btnSubmit_Click(object sender, System.EventArgs e)
    {
       OnSubmitClicked();
    }
