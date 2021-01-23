csharp
 public class UpdatePriorityCommand
 {
     public int PolicyWorkloadItemId { get; set; }
     public int Priority { get; set; }
 }
This class represents the **request** object in the following code.
csharp
//Get the item to change priority
PolicyWorkloadItem policyItem = await _ctx.PolicyWorkloadItems
                                          .FindAsync(request.PolicyWorkloadItemId);
//Get that item's priority and assign it to oldPriority variable
int oldPriority = policyItem.Priority.Value;
//Get the direction of change. 
//-1 == moving the item up in list
//+1 == moving the item down in list
int direction = oldPriority < request.Priority ? -1 : 1;
//Get list of items to update... 
List<PolicyWorkloadItem> policyItems = await _ctx.PolicyWorkloadItems
                                                 .Where(x => x.PolicyWorkloadItemId != request.PolicyWorkloadItemId)
                                                 .ToListAsync();
//Loop through and update values
foreach(var p in policyItems)
{
    //if moving item down in list (I.E. 3 to 1) then only update
    //items that are less than the old priority. (I.E. 1 to 2 and 2 to 3)
    //items greater than the new priority need not change (i.E. 4,5,6... etc.)
   
    //if moving item up in list (I.E. 1 to 3)
    //items less than or equal to the new value get moved down. (I.E. 2 to 1 and 3 to 2)
    //items greater than the new priority need not change (i.E. 4,5,6... etc.)
    if(
           (direction > 0 && p.Priority < oldPriority)
        || (direction < 0 && p.Priority > oldPriority && p.Priority <= request.Priority)
      )
    {  
        p.Priority += direction;
        _ctx.PolicyWorkloadItems.Update(p);
    }       
}
//finally update the priority of the target item directly
policyItem.Priority = request.Priority;
//track changes with EF Core
_ctx.PolicyWorkloadItems.Update(policyItem);
//Persist changes to database
await _ctx.SaveChangesAsync(cancellationToken);
