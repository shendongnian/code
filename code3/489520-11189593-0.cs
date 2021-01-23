    <td>
    @foreach (var invoiceLine in invoice.InvoiceLines)
    {
                    
        <p>
            <strong>@invoiceLine.Date.ToShortDateString() @invoiceLine.Username</strong> <br />
            @Html.Raw((invoiceLine.DueDate.HasValue ? "<br /><strong>Follow up:</strong> " + invoiceLine.DueDate.Value.ToShortDateString() : "")) 
            @Html.Raw(invoiceLine.Completed ? "<br /><strong>Completed</strong>" : "")
            <h3 class="notesClick">Open Notes</h3>
            <div class="notesHtml" style="display:none">
              @Html.Raw(invoiceLine.Notes.Replace(Environment.NewLine, "<br />")) 
            </div>
        </p>
    }
    </td>
