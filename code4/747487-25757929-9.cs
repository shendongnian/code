   		    private void UpdateStatisticsPanel()
    		{
    			var billingTypeId = int.Parse(txtBillingTypeId.Text);
    			
    			var totalMinutesInvoiced = context.udfGetTotalMinutesInvoiced(billingType: billingTypeId);
    			var minutesInvoiced = totalMinutesInvoiced.FirstOrDefault();
    			var invoiced = new Tuple<string, int?>("totalMinutesInvoiced:", minutesInvoiced);
    			lstFinancialSummary.Items.Add(invoiced);
    
    			var totalMinutesNotInvoiced = context.udfGetTotalMinutesNotInvoiced(billingType: billingTypeId);
    			var minutesNotInvoiced = totalMinutesNotInvoiced.FirstOrDefault();
    			var notInvoiced = new Tuple<string, int?>("totalMinutesNotInvoiced:", minutesNotInvoiced);
    
    			lstFinancialSummary.Items.Add(notInvoiced);
    			// remember to push the values up to the ListView.
    		}
