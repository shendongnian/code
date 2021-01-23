    @foreach (var currentProgramTypeViewModel in Model)
            { 
                foreach(string currentProgramType in currentProgramTypeViewModel.ProgramTypes)
                {
                    <h2>@currentProgramType</h2> 
    
                    <ul>
                        @for (int mProgramIndex = 0; mProgramIndex < currentProgramTypeViewModel.ProgramIds.Count(); mProgramIndex++)
                        {
                            var programTitle = currentProgramTypeViewModel.ProgramTitles.ToList<string>()[mProgramIndex];
                            var programId = currentProgramTypeViewModel.ProgramIds.ToList<int>()[mProgramIndex];
                            <li>
                                @Html.ActionLink(programTitle, "Results", "SurveyResponse", new { ProgramId = programId }, null)
                            </li>
                        }
                    </ul>
                }
            }
