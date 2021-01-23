    @model IList<Criterion>
    
    @using (Html.BeginForm())
    {
        for (int i = 0; i < Model.Count; i++)
        {
            <div>
                @Html.LabelFor(x => x[i], Model[i].Text)
                @Html.EditorFor(x => x[i].Value, "Criterion_" + Model[i].Value.GetType().Name)
            </div>
        }
        
        <button type="submit">OK</button>
    }
