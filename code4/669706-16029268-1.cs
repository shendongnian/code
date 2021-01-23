    <% for (int i = 0; i < Model.PossibleAnswers.Count; ++i) { %>
      {
         <label>
            <%= Html.RadioButtonFor(m => m.PossibleAnswers[i].TheAnswer, m.PossibleAnswers[i]..ID) m.PossibleAnswers[i].TheAnswer %> 
         </label>
    <% } %>
