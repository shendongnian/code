		using System;
		using Opit.Rogatus.DomainObjects;
		namespace MetaDataPortal.Models
		{
			public class AnswerDisplayItem
			{
				public Guid Id { get; private set; }
				public short Value { get; private set; }
				public string Text { get; private set; }
				public Guid AnswerSchemeId { get; set; }
				public bool IsMissing { get; private set; }
				public AnswerDisplayItem()
				{
				}
				public AnswerDisplayItem(Code code)
				{
					Id = code.Id;
					Value = code.Value;
					Text = code.Category.Name;
					IsMissing = code.Category.IsMissing;
					if (code.CodeList == null) return;
					AnswerSchemeId = code.CodeList.Id;
				}
			}
		}
