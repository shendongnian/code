    <div class="list-container">
        @for (int i = 0; i < Model.Items.Count; i = i + 8)
        {
            <ul>
                for (j = 0; j < 8; j++)
                {
                    <li>Model.Items[i+j].ContentItem.Title.Value</li>                        
                }
            </ul>
        }
    </div>
